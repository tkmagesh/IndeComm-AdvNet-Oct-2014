using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DIDemo.Contracts;

namespace ProductsTransformersCollection
{
    [Export(typeof(IProductDestination))]
    public class XmlProductDestination : IProductDestination
    {
        public void Save(List<Product> products)
        {
            new XElement("Products", products.Select(p => new XElement("Product",
                new XElement("Id", p.Id),
                new XElement("Name", p.Name),
                new XElement("Cost", p.Cost),
                new XElement("Units", p.Units),
                new XElement("Category", p.Category)
                ))
            ).Save("products.xml");
        }
    }
}
