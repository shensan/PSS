using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insigma.Eyes.PSS.Model;

namespace Insigma.Eyes.PSS.IDAL
{
    public interface ICommodityService:IBaseService<Model.CommodityModel>
    {
        List<UnitModel> GetUnitEntities(string sqlWhere);
        bool AddUnitEntity(UnitModel entity);
        bool UpdateUnitEntity(UnitModel entity);

        List<TypeModel> GetTypeEntities(string sqlWhere);
        bool AddTypeEntity(TypeModel entity);
        bool UpdateTypeEntity(TypeModel entity);
    }
}
