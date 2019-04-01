using AutoMapper;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DatabaseContext.DBOs
{
    public class MapperBase<ContractType, ModelType>
    {
        IMapper map;
        protected MapperConfiguration config;
        public MapperBase()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContractType, ModelType>();
                cfg.CreateMap<ModelType, ContractType>();
                cfg.CreateMap<Guid, Id>().ConvertUsing((guid) => (Id)guid);
                cfg.CreateMap<Id, Guid>().ConvertUsing((id) => (Guid)id);
            });
            
            map = config.CreateMapper();
        }

        public virtual ContractType ModelToContract(ModelType dbo)
        {
            return map.Map<ContractType>(dbo);
        }

        public virtual ModelType ContractToModel(ContractType contract)
        {
            return map.Map<ModelType>(contract);
        }

        public virtual IEnumerable<ContractType> ModelListToContractList(IEnumerable<ModelType> dboList)
        {
            return dboList.Select(dbo => ModelToContract(dbo));
        }
    }
}
