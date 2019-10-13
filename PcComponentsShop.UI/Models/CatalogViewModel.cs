using PcComponentsShop.UI.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PcComponentsShop.Domain.Core.Basic_Models;

namespace PcComponentsShop.UI.Models
{
    public class CatalogViewModel<TGoodType>
    {
        public IEnumerable<TGoodType> Goods { get; set; }
        public PageInfo PageInfo { get; set; }
        public static CatalogViewModel<TGoodType> GetCatalogViewModel(int page, int pageSize, IEnumerable<TGoodType> goods)
        {
            IEnumerable<TGoodType> goodsPerPages = goods.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = goods.Count() };
            return new CatalogViewModel<TGoodType> { PageInfo = pageInfo, Goods = goodsPerPages };
        }
    }
}