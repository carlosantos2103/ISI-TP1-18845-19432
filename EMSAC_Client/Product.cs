using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSAC_Client
{
    public class Product
    {
        #region Atributos
        private string name;
        private float price;
        #endregion

        #region Construtor

        public Product()
        {
            this.Name = "";
            this.Price = 0;
        }


        public Product(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }

        #endregion

        #region Propriedades


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        #endregion
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
