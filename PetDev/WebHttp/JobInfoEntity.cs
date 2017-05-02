using System;
using System.Collections.Generic;
using System.Text;

namespace PetDev
{
    /// <summary>
    /// 职位信息
    /// </summary>
    public class JobInfoEntity
    {
        private string jobID;

        /// <summary>
        /// 职位编号
        /// </summary>
        public string JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }
        private string title;

        /// <summary>
        /// 职位名称
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string jobDate;

        public string JobDate
        {
            get { return jobDate; }
            set { jobDate = value; }
        }
        private string refreshDate;

        public string RefreshDate
        {
            get { return refreshDate; }
            set { refreshDate = value; }
        }
        private string companyID;

        /// <summary>
        /// 公司编号
        /// </summary>
        public string CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }
        private string companyName;

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        private string companyDate;

        public string CompanyDate
        {
            get { return companyDate; }
            set { companyDate = value; }
        }
        private string memID;

        public string MemID
        {
            get { return memID; }
            set { memID = value; }
        }
        private string locNameCNs;

        /// <summary>
        /// 工作地点
        /// </summary>
        public string LocNameCNs
        {
            get { return locNameCNs; }
            set { locNameCNs = value; }
        }
        private string workExp;

        /// <summary>
        /// 工作经验
        /// </summary>
        public string WorkExp
        {
            get { return workExp; }
            set { workExp = value; }
        }
        private string jobCustomizedUrl;

        public string JobCustomizedUrl
        {
            get { return jobCustomizedUrl; }
            set { jobCustomizedUrl = value; }
        }
        private string companyApplyForm;

        public string CompanyApplyForm
        {
            get { return companyApplyForm; }
            set { companyApplyForm = value; }
        }
        private string salary;

        /// <summary>
        /// 薪水
        /// </summary>
        public string Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private string companyChr;

        public string CompanyChr
        {
            get { return companyChr; }
            set { companyChr = value; }
        }
        private string degree;

        /// <summary>
        /// 学位
        /// </summary>
        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        private string companySize;

        /// <summary>
        /// 公司规模
        /// </summary>
        public string CompanySize
        {
            get { return companySize; }
            set { companySize = value; }
        }
        private string totalHire;

        public string TotalHire
        {
            get { return totalHire; }
            set { totalHire = value; }
        }
        private string duty;

        public string Duty
        {
            get { return duty; }
            set { duty = value; }
        }

    }
}
