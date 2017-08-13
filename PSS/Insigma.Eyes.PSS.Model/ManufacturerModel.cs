using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Insigma.Eyes.PSS.Model
{
    /// <summary>
    /// 厂商与供应商信息
    /// </summary>
    [DataContract]
    public class ManufacturerModel
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        ///供应商联系人
        /// </summary>
        [DataMember]
        public string Person { get; set; }
        /// <summary>
        /// 供应商电话
        /// </summary>
        [DataMember]
        public string Telphone { get; set; }
        /// <summary>
        /// 供应商地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [DataMember]
        public string Status { get; set; }
    }
}
