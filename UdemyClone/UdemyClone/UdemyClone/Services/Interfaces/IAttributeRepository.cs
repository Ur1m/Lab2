using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.DTO;

namespace UdemyClone.Services.Interfaces
{
  public interface IAttributeRepository
    {
        public List<AttributeDTO> getAllAtributes();
        public List<AttributeValueDTO> getAttributeValuesByProductId(int id);
        public List<AttributeValueDTO> getAttributeVAluesByAttributeId(int id);
        public List<ProductDTO> getProductbyAttributeValue(int id);
        public void AddAtribute(AttributeDTO atr);
        public void AddAttributeValue(AttributeValueDTO atrval);
        public void AddProductAttr(ProductAttributeDTO prodatr);
        public void DeleteAttributeValue(int id);
        public void DeleteAttribute(int id);
        public void DeleteAttributeValueForProduct(int prodId, int attrid);
        public List<AttributeValueDTO> getAllAtrvalues();
    }
}
