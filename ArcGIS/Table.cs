using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesOleDB;
using ESRI.ArcGIS.DataSourcesGDB;

namespace Town.ArcGIS
{
    class Table
    {
        /// <summary>
        /// Join Urban-rural Devide Table 
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="year"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static void JoinDevideTable(ILayer layer, int year, string city)
        {
            //Add Fields
            IFieldsEdit allFields = new FieldsClass();
            IFieldEdit field1 = new FieldClass();
            field1.Name_2 = "ID";
            field1.Type_2 = esriFieldType.esriFieldTypeString;
            allFields.AddField(field1);
            IFieldEdit field2 = new FieldClass();
            field2.Name_2 = Town.Constant.Constant.TmpFieldName;
            field2.Type_2 = esriFieldType.esriFieldTypeString;
            allFields.AddField(field2);

            //Create Table
            IWorkspaceFactory workspaceFactory = new InMemoryWorkspaceFactoryClass();
            IWorkspaceName workspaceName = workspaceFactory.Create("", "Temporary WorkSpace In Memory", null, 0);
            IFeatureWorkspace workspace = ((IName)workspaceName).Open() as IFeatureWorkspace;
            ITable table = workspace.CreateTable(Town.Constant.Constant.TmpTableDevide, allFields, null, null, "");

            //Import Data
            IWorkspaceEdit workspaceEdit = workspace as IWorkspaceEdit;
            workspaceEdit.StartEditing(false);
            workspaceEdit.StartEditOperation();
            ICursor cursor = table.Insert(true);
            int fldField1 = cursor.Fields.FindField("ID");
            int fldField2 = cursor.Fields.FindField(Town.Constant.Constant.TmpFieldName);


            //Query and Import
            Dictionary<int, string> devideResult = DataLib.DA_Devide.GetDevideResult(year, city);
            foreach (KeyValuePair<int, string> d in devideResult)
            {
                IRowBuffer buffer = table.CreateRowBuffer();
                buffer.set_Value(fldField1, d.Key.ToString());
                buffer.set_Value(fldField2, d.Value);
                cursor.InsertRow(buffer);
            }

            cursor.Flush();
            workspaceEdit.StartEditOperation();
            workspaceEdit.StopEditing(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);

            //Join
            IMemoryRelationshipClassFactory pMemRelFact = new MemoryRelationshipClassFactory();
            IFeatureLayer feaLayer = layer as IFeatureLayer;
            ITable originTable = feaLayer.FeatureClass as ITable;
            IRelationshipClass pRelClass = pMemRelFact.Open("Join", originTable as IObjectClass, "ID",
                table as IObjectClass, "ID", "forward", "backward",
                esriRelCardinality.esriRelCardinalityOneToOne);
            IDisplayRelationshipClass pDispRC = feaLayer as IDisplayRelationshipClass;
            pDispRC.DisplayRelationshipClass(null, esriJoinType.esriLeftOuterJoin);
            pDispRC.DisplayRelationshipClass(pRelClass, esriJoinType.esriLeftOuterJoin);
        }

        /// <summary>
        /// Join Complex Index Table 
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="year"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static void JoinComplexTable(ILayer layer, int year, string city, bool normal)
        {
            //Add Fields
            IFieldsEdit allFields = new FieldsClass();
            IFieldEdit field1 = new FieldClass();
            field1.Name_2 = "ID";
            field1.Type_2 = esriFieldType.esriFieldTypeString;
            allFields.AddField(field1);
            IFieldEdit field2 = new FieldClass();
            field2.Name_2 = "Ecology";
            field2.Type_2 = esriFieldType.esriFieldTypeDouble;
            allFields.AddField(field2);
            IFieldEdit field3 = new FieldClass();
            field3.Name_2 = "Social";
            field3.Type_2 = esriFieldType.esriFieldTypeDouble;
            allFields.AddField(field3);
            IFieldEdit field4 = new FieldClass();
            field4.Name_2 = "Economic";
            field4.Type_2 = esriFieldType.esriFieldTypeDouble;
            allFields.AddField(field4);

            //Create Table
            IWorkspaceFactory workspaceFactory = new InMemoryWorkspaceFactoryClass();
            IWorkspaceName workspaceName = workspaceFactory.Create("", "Temporary WorkSpace In Memory", null, 0);
            IFeatureWorkspace workspace = ((IName)workspaceName).Open() as IFeatureWorkspace;
            ITable table = workspace.CreateTable(Town.Constant.Constant.TmpTableIndex, allFields, null, null, "");


            //Import Data
            IWorkspaceEdit workspaceEdit = workspace as IWorkspaceEdit;
            workspaceEdit.StartEditing(false);
            workspaceEdit.StartEditOperation();
            ICursor cursor = table.Insert(true);
            int fldField1 = cursor.Fields.FindField("ID");
            int fldField2 = cursor.Fields.FindField("Ecology");
            int fldField3 = cursor.Fields.FindField("Social");
            int fldField4 = cursor.Fields.FindField("Economic");

            IQueryable<DataLib.I_INDEX> indexCollect = DataLib.DA_Index.QueryIndex(year, city);
            List<int> OIDList = new List<int>();

            foreach (DataLib.I_INDEX i in indexCollect)
            {
                if (OIDList.Contains(i.I_ZONE.OID) == false)
                {
                    double EcologyValue = indexCollect.Where(c => c.Name.Equals("生态子系统综合指标") && c.Zone == i.Zone).Single().Value;
                    double SocialValue = indexCollect.Where(c => c.Name.Equals("社会子系统综合指标") && c.Zone == i.Zone).Single().Value;
                    double EconomicValue = indexCollect.Where(c => c.Name.Equals("经济子系统综合指标") && c.Zone == i.Zone).Single().Value;

                    //if (normal == true)
                    //{
                    //    EcologyValue += Math.Abs(DataLib.DA_Index.QueryIndex("生态子系统综合指标", city).Min(c => c.Value)) + 1;
                    //    SocialValue += Math.Abs(DataLib.DA_Index.QueryIndex("社会子系统综合指标", city).Min(c => c.Value)) + 1;
                    //    EconomicValue += Math.Abs(DataLib.DA_Index.QueryIndex("经济子系统综合指标", city).Min(c => c.Value)) + 1;
                    //}

                    EcologyValue = Math.Abs(EcologyValue);
                    SocialValue = Math.Abs(SocialValue);
                    EconomicValue = Math.Abs(EconomicValue);
                    IRowBuffer buffer = table.CreateRowBuffer();
                    buffer.set_Value(fldField1, i.I_ZONE.OID);
                    buffer.set_Value(fldField2, EcologyValue);
                    buffer.set_Value(fldField3, SocialValue);
                    buffer.set_Value(fldField4, EconomicValue);
                    cursor.InsertRow(buffer);

                    OIDList.Add(i.I_ZONE.OID);
                }
            }

            cursor.Flush();
            workspaceEdit.StartEditOperation();
            workspaceEdit.StopEditing(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);


            //Join
            IMemoryRelationshipClassFactory pMemRelFact = new MemoryRelationshipClassFactory();
            IFeatureLayer feaLayer = layer as IFeatureLayer;
            ITable originTable = feaLayer.FeatureClass as ITable;
            IRelationshipClass pRelClass = pMemRelFact.Open("Join", originTable as IObjectClass, "ID",
                table as IObjectClass, "ID", "forward", "backward",
                esriRelCardinality.esriRelCardinalityOneToOne);
            IDisplayRelationshipClass pDispRC = feaLayer as IDisplayRelationshipClass;
            pDispRC.DisplayRelationshipClass(null, esriJoinType.esriLeftOuterJoin);
            pDispRC.DisplayRelationshipClass(pRelClass, esriJoinType.esriLeftOuterJoin);
        }

        /// <summary>
        /// Join Index 
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="year"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static void JoinIndexTable(ILayer layer, string indexName, int year, string city, bool normal)
        {
            //Add Fields
            IFieldsEdit allFields = new FieldsClass();
            IFieldEdit field1 = new FieldClass();
            field1.Name_2 = "ID";
            field1.Type_2 = esriFieldType.esriFieldTypeString;
            allFields.AddField(field1);
            IFieldEdit field2 = new FieldClass();
            field2.Name_2 = Town.Constant.Constant.TmpFieldName;
            field2.Type_2 = esriFieldType.esriFieldTypeDouble;
            allFields.AddField(field2);

            //Create Table
            IWorkspaceFactory workspaceFactory = new InMemoryWorkspaceFactoryClass();
            IWorkspaceName workspaceName = workspaceFactory.Create("", "Temporary WorkSpace In Memory", null, 0);
            IFeatureWorkspace workspace = ((IName)workspaceName).Open() as IFeatureWorkspace;
            ITable table = workspace.CreateTable(Town.Constant.Constant.TmpTableIndex, allFields, null, null, "");

            //Import Data
            IWorkspaceEdit workspaceEdit = workspace as IWorkspaceEdit;
            workspaceEdit.StartEditing(false);
            workspaceEdit.StartEditOperation();
            ICursor cursor = table.Insert(true);
            int fldField1 = cursor.Fields.FindField("ID");
            int fldField2 = cursor.Fields.FindField(Town.Constant.Constant.TmpFieldName);

            IQueryable<DataLib.I_INDEX> indexCollect = DataLib.DA_Index.QueryIndex(indexName, city).Where(c => c.FromDate.Year == year);

            foreach (DataLib.I_INDEX index in indexCollect)
            {
                IRowBuffer buffer = table.CreateRowBuffer();
                buffer.set_Value(fldField1, index.I_ZONE.OID);
                if (normal == false)
                {
                    buffer.set_Value(fldField2, index.Value);
                }
                else if (normal == true && DataLib.DA_Index.QueryIndex(indexName, city).Min(c => c.Value) > 0)
                {
                    buffer.set_Value(fldField2, index.Value);
                }
                else
                {
                    buffer.set_Value(fldField2, index.Value + Math.Abs(DataLib.DA_Index.QueryIndex(indexName, city).Min(c => c.Value)) + 1);
                }
                cursor.InsertRow(buffer);
            }

            cursor.Flush();
            workspaceEdit.StartEditOperation();
            workspaceEdit.StopEditing(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);

            //Join
            IMemoryRelationshipClassFactory pMemRelFact = new MemoryRelationshipClassFactory();
            IFeatureLayer feaLayer = layer as IFeatureLayer;
            ITable originTable = feaLayer.FeatureClass as ITable;
            IRelationshipClass pRelClass = pMemRelFact.Open("Join", originTable as IObjectClass, "ID",
                table as IObjectClass, "ID", "forward", "backward",
                esriRelCardinality.esriRelCardinalityOneToOne);
            IDisplayRelationshipClass pDispRC = feaLayer as IDisplayRelationshipClass;
            pDispRC.DisplayRelationshipClass(null, esriJoinType.esriLeftOuterJoin);
            pDispRC.DisplayRelationshipClass(pRelClass, esriJoinType.esriLeftOuterJoin);
        }
    }
}
