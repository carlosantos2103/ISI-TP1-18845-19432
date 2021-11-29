using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSAC_Client
{
    public class Product
    {
        public int id { get; set; }
        public int procuct_id { get; set; }
        public string label { get; set; }
        public double unitPrice { get; set; }

        public Product()
        {
            this.id = 0;
            this.label = "";
            this.unitPrice = 0;
        }


        public Product(string name, float price)
        {
            this.id = 0;
            this.label = name;
            this.unitPrice =price;
        }
    }

    public static class Products
    {
        #region Atributos
        const int max = 100;
        static List<Product> lst_product;
        #endregion

        #region Construtor
        static Products()
        {
            lst_product = new List<Product>(max);
        }

        #endregion

        #region Metodos

        public static int Add_Product(Product p)
        {
            try
            {
                if (lst_product.Count == max)
                {
                    return 0;
                }

                // Testar se ja existe esse Produto
                if (lst_product.Contains(p))
                {
                    return 0;
                }

                // Adicionar esse Produto
                lst_product.Add(p);

                return 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Product> Show_Product()
        {
            try
            {
                List<Product> aux = new List<Product>();
                foreach (Product item in lst_product)
                {
                    aux.Add(item);
                }

                return aux;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
    }
}
