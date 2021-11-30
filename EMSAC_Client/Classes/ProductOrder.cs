using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSAC_Client
{
    public class ProductOrder
    {
        private int id_product;
        private float unitPrice;
        private int quantity;

        public ProductOrder(int id_p, int q, float uPrice)
        {
            this.Id_product = id_p;
            this.Quantity = q;
            this.UnitPrice = uPrice;
        }

        public ProductOrder(int id_p, int q)
        {
            this.Id_product = id_p;
            this.Quantity = q;
            this.UnitPrice = 0;
        }

        public int Id_product
        {
            get => id_product;
            set => id_product = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public float UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }
    }


    public static class ProductsOrder
    {
        #region Atributos
        const int max = 100;
        static List<ProductOrder> lst;
        #endregion

        #region Construtor
        static ProductsOrder()
        {
            lst = new List<ProductOrder>();
        }

        #endregion

        #region Metodos

        public static int Add_ProductOrder(ProductOrder p)
        {
            try
            {
                if (lst.Count == max)
                {
                    return 0;
                }

                if (lst.Contains(p))
                {
                    return 0;
                }

                // Adicionar esse Produto
                lst.Add(p);

                return 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<ProductOrder> Show_ProductOrder()
        {
            try
            {
                List<ProductOrder> aux = new List<ProductOrder>();
                foreach (ProductOrder item in lst)
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
