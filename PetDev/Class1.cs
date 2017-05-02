﻿//using System;
//using System.Text;
//using System.Data;
//using System.Collections;
//using System.Data.SqlClient;
//using eHR.DBModules;
//namespace eHR.BLL
//{
//    ///<summary>
//    /// 创建者:     小草
//    /// 创建时间:   2011-04-12
//    /// 修改者:     小草
//    /// 修改时间:   0000-00-00
//    /// 修改内容:   
//    /// 类功能描述: 
//    ///</summary>
//    public class BLLOpr : SQLHelper
//    {
//        ///<summary>
//        /// 构造函数 
//        ///</summary>
//        public BLLOpr()
//        {
//            //
//            // 在此处添加构造函数逻辑
//            //
//        }
//        /// <summary>
//        /// 作者:     小草
//        /// 创建时间: 2011-04-12
//        /// 功能描述: 根据条件获取查询数据
//        /// </summary>
//        /// <param name=" p_objMDOpr">
//        /// 查询条件HashTable的Key为:
//        /// 1: OrgID--角色ID:
//        /// 2: CreateDate--生成日期:
//        /// 3: UpdateDate--更新日期:
//        /// </param>
//        /// <returns>返回查询结果结合</returns>
//        public DataTable GetOrgInfo(eHR.Modules.MDOpr p_objMDOpr)
//        {
//            string strSQL = "";
//            strSQL = "select OrgID,OrgCode,CtmID,Cname,Ename,ListIndex,TaxTye,OprID,Status,CreateDate,UpdateDate  from Org where OrgID=@OrgID and CreateDate=@CreateDate and UpdateDate=@UpdateDate";
//            SqlParameter[] objParameter = new SqlParameter[3];

//            objParameter[0] = new SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4);
//            objParameter[0].Value = p_objMDOpr.intOrgID;

//            objParameter[1] = new SqlParameter("@CreateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[1].Value = p_objMDOpr.dtmCreateDate;

//            objParameter[2] = new SqlParameter("@UpdateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[2].Value = p_objMDOpr.dtmUpdateDate;

//            return this.ExecuteReadTable(strSQL, objParameter);
//        }
//        /// <summary>
//        /// 作者:     小草
//        /// 创建时间: 2011-04-12
//        /// 功能描述: 根据条件获取查询数据
//        /// </summary>
//        /// <param name=" p_objMDOpr">
//        /// 查询条件HashTable的Key为:
//        /// 1: OrgID--角色ID:
//        /// 2: CreateDate--生成日期:
//        /// 3: UpdateDate--更新日期:
//        /// </param>
//        /// <returns>返回查询结果结合</returns>
//        public DataTable GetOrgList(eHR.Modules.MDOpr p_objMDOpr, int p_intStart, int p_intPageSize, ref int Out_Count, string p_strOrderBy)
//        {
//            SqlParameter[] objParameter = new SqlParameter[0];
//            string strWhere = "";
//            SqlParameter SPNewParm = null;
//            ArrayList listParam = new ArrayList();
//            string strSQL = "";
//            strSQL = "select OrgID,OrgCode,CtmID,Cname,Ename,ListIndex,TaxTye,OprID,Status,CreateDate,UpdateDate  from Org where ";

//            if (p_objMDOpr.intOrgID != int.MinValue)
//            {
//                SPNewParm = new SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4);
//                SPNewParm.Value = p_objMDOpr.intOrgID;
//                listParam.Add(SPNewParm);
//                strWhere += " and OrgID =@OrgID  ";
//            }

//            if (p_objMDOpr.dtmCreateDate != "" && p_objMDOpr.dtmCreateDate != null)
//            {
//                SPNewParm = new SqlParameter("@CreateDate", System.Data.SqlDbType.VarChar, 8);
//                SPNewParm.Value = p_objMDOpr.dtmCreateDate;
//                listParam.Add(SPNewParm);
//                strWhere += " and CreateDate =@CreateDate  ";
//            }

//            if (p_objMDOpr.dtmUpdateDate != "" && p_objMDOpr.dtmUpdateDate != null)
//            {
//                SPNewParm = new SqlParameter("@UpdateDate", System.Data.SqlDbType.VarChar, 8);
//                SPNewParm.Value = p_objMDOpr.dtmUpdateDate;
//                listParam.Add(SPNewParm);
//                strWhere += " and UpdateDate =@UpdateDate  ";
//            }

//            objParameter = (SqlParameter[])listParam.ToArray(typeof(SqlParameter));
//            if (p_strOrderBy.Trim() != "")
//            {
//                p_strOrderBy = " order by " + p_strOrderBy;
//            }
//            strSQL = strSQL + strWhere + p_strOrderBy;
//            return this.ExecuteReadTable(strSQL, objParameter, p_intStart, p_intPageSize, ref Out_Count);
//        }

//        /// <summary>
//        /// 作者:     小草
//        /// 创建时间: 2011-04-12
//        /// 功能描述: 插入表数据
//        /// </summary>
//        /// <param name="p_objMDOpr">
//        /// 插入列为:
//        /// 1: OrgID--角色ID:
//        /// 2: OrgCode--组织编码:
//        /// 3: CtmID--客户ID:
//        /// 4: Cname--中文名:
//        /// 5: Ename--英文名:
//        /// 6: ListIndex--显示顺序:
//        /// 7: TaxTye--缴税地区:数据字典
//        /// 8: OprID--操作员ID:
//        /// 9: Status--状态:01-有效 06-删除
//        /// 10: CreateDate--生成日期:
//        /// 11: UpdateDate--更新日期:
//        /// </param>
//        /// <returns>返回影响行数</returns>
//        public int InsertOrg(eHR.Modules.MDOpr p_objMDOpr)
//        {
//            string strSQL = "";
//            strSQL = "insert into   Org (  OrgID,OrgCode,CtmID,Cname,Ename,ListIndex,TaxTye,OprID,Status,CreateDate,UpdateDate ) values ( @OrgID,@OrgCode,@CtmID,@Cname,@Ename,@ListIndex,@TaxTye,@OprID,@Status,@CreateDate,@UpdateDate)";
//            SqlParameter[] objParameter = new SqlParameter[11];

//            objParameter[0] = new SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4);
//            objParameter[0].Value = p_objMDOpr.intOrgID;

//            objParameter[1] = new SqlParameter("@OrgCode", System.Data.SqlDbType.VarChar, 255);
//            objParameter[1].Value = p_objMDOpr.strOrgCode;

//            objParameter[2] = new SqlParameter("@CtmID", System.Data.SqlDbType.Int, 4);
//            objParameter[2].Value = p_objMDOpr.intCtmID;

//            objParameter[3] = new SqlParameter("@Cname", System.Data.SqlDbType.VarChar, 100);
//            objParameter[3].Value = p_objMDOpr.strCname;

//            objParameter[4] = new SqlParameter("@Ename", System.Data.SqlDbType.VarChar, 100);
//            objParameter[4].Value = p_objMDOpr.strEname;

//            objParameter[5] = new SqlParameter("@ListIndex", System.Data.SqlDbType.Int, 4);
//            objParameter[5].Value = p_objMDOpr.intListIndex;

//            objParameter[6] = new SqlParameter("@TaxTye", System.Data.SqlDbType.VarChar, 4);
//            objParameter[6].Value = p_objMDOpr.strTaxTye;

//            objParameter[7] = new SqlParameter("@OprID", System.Data.SqlDbType.Int, 4);
//            objParameter[7].Value = p_objMDOpr.intOprID;

//            objParameter[8] = new SqlParameter("@Status", System.Data.SqlDbType.Char, 2);
//            objParameter[8].Value = p_objMDOpr.strStatus;

//            objParameter[9] = new SqlParameter("@CreateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[9].Value = p_objMDOpr.dtmCreateDate;

//            objParameter[10] = new SqlParameter("@UpdateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[10].Value = p_objMDOpr.dtmUpdateDate;

//            return this.ExecuteSQL(strSQL, objParameter);
//        }

//        /// <summary>
//        /// 作者:     ***
//        /// 创建时间: 2011-04-12
//        /// 功能描述: 根据条件更新表数据
//        /// </summary>
//        /// <param name="p_objMDOpr">
//        /// 更新条件为:
//        /// 1: OrgID--角色ID:
//        /// 2: CreateDate--生成日期:
//        /// 3: UpdateDate--更新日期:
//        /// 更新字段为:
//        /// 1: OrgID--角色ID:
//        /// 2: OrgCode--组织编码:
//        /// 3: CtmID--客户ID:
//        /// 4: Cname--中文名:
//        /// 5: Ename--英文名:
//        /// 6: ListIndex--显示顺序:
//        /// 7: TaxTye--缴税地区:数据字典
//        /// 8: OprID--操作员ID:
//        /// 9: Status--状态:01-有效 06-删除
//        /// 10: CreateDate--生成日期:
//        /// 11: UpdateDate--更新日期:
//        /// </param>
//        /// <returns>返回影响行数</returns>
//        public int UpdateOrg(eHR.Modules.MDOpr p_objMDOpr)
//        {
//            string strSQL = "";
//            strSQL = "update  Org set  OrgID=@OrgID,OrgCode=@OrgCode,CtmID=@CtmID,Cname=@Cname,Ename=@Ename,ListIndex=@ListIndex,TaxTye=@TaxTye,OprID=@OprID,Status=@Status,CreateDate=@CreateDate,UpdateDate=@UpdateDate    where OrgID=@OrgID and CreateDate=@CreateDate and UpdateDate=@UpdateDate";
//            SqlParameter[] objParameter = new SqlParameter[14];


//            objParameter[0] = new SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4);
//            objParameter[0].Value = p_objMDOpr.intOrgID;

//            objParameter[1] = new SqlParameter("@OrgCode", System.Data.SqlDbType.VarChar, 255);
//            objParameter[1].Value = p_objMDOpr.strOrgCode;

//            objParameter[2] = new SqlParameter("@CtmID", System.Data.SqlDbType.Int, 4);
//            objParameter[2].Value = p_objMDOpr.intCtmID;

//            objParameter[3] = new SqlParameter("@Cname", System.Data.SqlDbType.VarChar, 100);
//            objParameter[3].Value = p_objMDOpr.strCname;

//            objParameter[4] = new SqlParameter("@Ename", System.Data.SqlDbType.VarChar, 100);
//            objParameter[4].Value = p_objMDOpr.strEname;

//            objParameter[5] = new SqlParameter("@ListIndex", System.Data.SqlDbType.Int, 4);
//            objParameter[5].Value = p_objMDOpr.intListIndex;

//            objParameter[6] = new SqlParameter("@TaxTye", System.Data.SqlDbType.VarChar, 4);
//            objParameter[6].Value = p_objMDOpr.strTaxTye;

//            objParameter[7] = new SqlParameter("@OprID", System.Data.SqlDbType.Int, 4);
//            objParameter[7].Value = p_objMDOpr.intOprID;

//            objParameter[8] = new SqlParameter("@Status", System.Data.SqlDbType.Char, 2);
//            objParameter[8].Value = p_objMDOpr.strStatus;

//            objParameter[9] = new SqlParameter("@CreateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[9].Value = p_objMDOpr.dtmCreateDate;

//            objParameter[10] = new SqlParameter("@UpdateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[10].Value = p_objMDOpr.dtmUpdateDate;

//            objParameter[11] = new SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4);
//            objParameter[11].Value = p_objMDOpr.intOrgID;

//            objParameter[12] = new SqlParameter("@CreateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[12].Value = p_objMDOpr.dtmCreateDate;

//            objParameter[13] = new SqlParameter("@UpdateDate", System.Data.SqlDbType.VarChar, 8);
//            objParameter[13].Value = p_objMDOpr.dtmUpdateDate;

//            return this.ExecuteSQL(strSQL, objParameter);
//        }

//        /// <summary>
//        /// 作者:     小草
//        /// 创建时间: 2011-04-12
//        /// 功能描述: 根据条件删除
//        /// </summary>
//        /// <param name="p_objMDOpr">
//        /// 条件参数为:
//        /// 1: OrgID--角色ID:
//        /// 2: CreateDate--生成日期:
//        /// 3: UpdateDate--更新日期:
//        /// </param>
//        /// <returns>返回影响行数</returns>
//        public int DeleteOrgInfo(eHR.Modules.MDOpr p_objMDOpr)
//        {
//            string strSQL = "";
//            strSQL = "delete     from Org where OrgID=@OrgID and CreateDate=@CreateDate and UpdateDate=@UpdateDate";
//            SqlParameter[] objParmas = new SqlParameter[3];
//            objParmas[0] = new SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4);
//            objParmas[0].Value = p_objMDOpr.intOrgID;

//            objParmas[1] = new SqlParameter("@CreateDate", System.Data.SqlDbType.VarChar, 8);
//            objParmas[1].Value = p_objMDOpr.dtmCreateDate;

//            objParmas[2] = new SqlParameter("@UpdateDate", System.Data.SqlDbType.VarChar, 8);
//            objParmas[2].Value = p_objMDOpr.dtmUpdateDate;

//            return this.ExecuteSQL(strSQL, objParmas);
//        }

//    }
//}
