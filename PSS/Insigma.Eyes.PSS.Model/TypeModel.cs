using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Insigma.Eyes.PSS.Model
{
    /// <summary>
    /// 商品类型数据
    /// </summary>
    [DataContract]
    public class TypeModel
    {
        /// <summary>
        /// 类型ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 类型状态
        /// </summary>
        [DataMember]
        public string Status { get; set; }
        /// <summary>
        /// 类型序号
        /// </summary>
        [DataMember]
        public int Line { get; set; }
        /// <summary>
        /// 类型备注
        /// </summary>
        [DataMember]
        public string Mark { get; set; }
    }
}
