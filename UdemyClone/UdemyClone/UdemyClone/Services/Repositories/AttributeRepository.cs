using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.Database;
using UdemyClone.DTO;
using UdemyClone.Services.Interfaces;
using UdemyClone.Models;
using Attribute = UdemyClone.Models.Attribute;
using Microsoft.EntityFrameworkCore;

namespace UdemyClone.Services.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private ProductDB _db;
        private IMapper _mapper;

        public AttributeRepository(ProductDB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddAttribute(AttributeDTO atr)
        {
           var attr=_mapper.Map<Attribute>(atr);
           
           _db.atribues.Add(attr);
           _db.SaveChanges();
        }

        public void AddAttributeValue(AttributeValueDTO atrval)
        {
            var attrvalue = _mapper.Map<AttributeValue>(atrval);

            _db.atrvalues.Add(attrvalue);
            _db.SaveChanges();
        }

        public void AddProductAttr(ProductAttributeDTO prodatr)
        {
            var prod = _mapper.Map<ProductAttribute>(prodatr);

            _db.productattributes.Add(prod);

            _db.SaveChanges();
        }

        public void DeleteAttribute(int id)
        {
            var atr = _db.atribues.Where(x => x.AttributeId == id).FirstOrDefault();

            _db.atribues.Remove(atr);
            _db.SaveChanges();
        }

        public void DeleteAttributeValue(int id)
        {
            var attribute = _db.atrvalues.Where(x => x.AttributeValueId == id).FirstOrDefault();

            _db.atrvalues.Remove(attribute);
            _db.SaveChanges();
        }

        public void DeleteAttributeValueForProduct(int prodId, int attrid)
        {
            var atr = _db.productattributes.Where(x => x.Id == prodId && x.AttributeValueId == attrid).FirstOrDefault();

            _db.productattributes.Remove(atr);
            _db.SaveChanges();
        }

        public List<AttributeDTO> getAllAtributes()
        {
            var attrs = _db.atribues.Select(x => _mapper.Map<AttributeDTO>(x)).ToList();

            return attrs;
        }

        public List<AttributeValueDTO> getAllAtrvalues()
        {
            var attrs = _db.atrvalues.Select(x => _mapper.Map<AttributeValueDTO>(x)).ToList();

            return attrs;
        }

        public List<AttributeValueDTO> getAttributeVAluesByAttributeId(int id)
        {
            var attrs = _db.atrvalues.Where(x=> x.AttributeId==id).Select(x => _mapper.Map<AttributeValueDTO>(x)).ToList();

            return attrs;
        }

        public List<AttributeValueDTO> getAttributeValuesByProductId(int id)
        {
            var attr = _db.productattributes.Where(x => x.Id == id).Select(x => x.AttributeValueId).ToList();

            var atrvalues = new List<AttributeValueDTO>();

            foreach(var item in attr)
            {
                atrvalues.Add(_db.atrvalues.Where(x => x.AttributeValueId == item).Select(x=> _mapper.Map<AttributeValueDTO>(x)).FirstOrDefault());
            }

            return atrvalues;
        }

        public List<ProductDTO> getProductbyAttributeValue(int id)
        {
            var prod = _db.productattributes.Where(x => x.AttributeValueId == id).Include(x => x.product)
                                            .Select(x => _mapper.Map<ProductDTO>(x.product)).ToList();

            return prod;
        }
    }
}
