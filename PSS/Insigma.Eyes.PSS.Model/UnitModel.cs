using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Insigma.Eyes.PSS.Model
{
    /// <summary>
    /// 商品单位数据
    /// </summary>
    [DataContract]
    public class UnitModel
    {
        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 单位状态
        /// </summary>
        [DataMember]
        public string Status { get; set; }
        /// <summary>
        /// 单位序号
        /// </summary>
        [DataMember]
        public int Line { get; set; }
        /// <summary>
        /// 单位备注
        /// </summary>
        [DataMember]
        public string Mark { get; set; }
    }
}
