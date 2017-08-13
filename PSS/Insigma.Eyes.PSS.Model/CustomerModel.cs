using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Insigma.Eyes.PSS.Model
{
    /// <summary>
    /// 顾客信息
    /// </summary>
    [DataContract]
    public class CustomerModel
    {
        /// <summary>
        /// 顾客ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 顾客姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 顾客生日
        /// </summary>
        [DataMember]
        public string Birthday { get; set; }
        /// <summary>
        /// 顾客电话
        /// </summary>
        [DataMember]
        public string Telphone { get; set; }
        /// <summary>
        /// 顾客地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        ///顾客历史消费
        /// </summary>
        [DataMember]
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Mark { get; set; }
    }
}
