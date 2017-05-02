using System;
using System.Collections.Generic;
using System.Text;

namespace PetDev
{
    public class JobsEntity
    {
        private int recordCount;

        /// <summary>
        /// 显示多少条记录
        /// </summary>
        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }
        private int trueCount;
        
        /// <summary>
        /// 共多少条记录
        /// </summary>
        public int TrueCount
        {
            get { return trueCount; }
            set { trueCount = value; }
        }
        private List<JobInfoEntity> jobs;

        /// <summary>
        /// 职位信息
        /// </summary>
        public List<JobInfoEntity> Jobs
        {
            get { return jobs; }
            set { jobs = value; }
        }
    }
}
