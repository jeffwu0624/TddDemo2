using System;
using System.Runtime.InteropServices;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculator_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var product = CreateProduct();

                var companyName = "";
                var fee = 0d;

                if ("1".Equals(ddlLogistics.SelectedValue))
                {
                    //CalculatedByBlackCat();

                    var blackCat = new BlackCat() { ShipProduct = product };
                    blackCat.Calculated();

                    companyName = blackCat.GetCompanyName();
                    fee = blackCat.GetFee();
                }
                else if ("2".Equals(ddlLogistics.SelectedValue))
                {
                    //CalculateHsinchu();

                    var hsinchu = new Hsinchu() { ShipProduct = product };
                    hsinchu.Calculated();

                    companyName = hsinchu.GetCompanyName();
                    fee = hsinchu.GetFee();
                }
                else if ("3".Equals(ddlLogistics.SelectedValue))
                {
                    //CalculatedByPostOffice();
                    var postOffice = new PostOffice() { ShipProduct = product };
                    postOffice.Calculated();

                    companyName = postOffice.GetCompanyName();
                    fee = postOffice.GetFee();
                }

                lblLogistics.Text = companyName;
                lblFee.Text = fee.ToString("C");
            }
        }

        private void CalculatedByPostOffice()
        {
            lblLogistics.Text = ddlLogistics.SelectedItem.Text;

            var weight = Convert.ToDouble(txtWeight.Text);
            var feeByWeight = 80 + (weight * 10);

            var width = Convert.ToDouble(txtWidth.Text);
            var length = Convert.ToDouble(txtLength.Text);
            var height = Convert.ToDouble(txtHeight.Text);

            var size = width * length * height;
            var feeBySize = size * 0.0000353 * 1100;

            if (feeByWeight < feeBySize)
            {
                lblFee.Text = feeByWeight.ToString("C");
            }
            else
            {
                lblFee.Text = feeBySize.ToString("C");
            }
        }

        private void CalculateHsinchu()
        {
            lblLogistics.Text = ddlLogistics.SelectedItem.Text;

            var width = Convert.ToDouble(txtWidth.Text);
            var length = Convert.ToDouble(txtLength.Text);
            var height = Convert.ToDouble(txtHeight.Text);

            var size = (width * length * height);

            if (length > 100 || width > 100 || height > 100)
            {
                lblFee.Text = (size * 0.0000353 * 1100 + 500).ToString("C");
            }
            else
            {
                lblFee.Text = (size * 0.0000353 * 1200).ToString("C");
            }
        }

        private void CalculatedByBlackCat()
        {
            lblLogistics.Text = ddlLogistics.SelectedItem.Text;

            var weight = Convert.ToDouble(txtWeight.Text);

            if (weight > 20)
            {
                lblFee.Text = 500.ToString("C");
            }
            else
            {
                lblFee.Text = (100 + weight * 10).ToString("C");
            }
        }

        private Product CreateProduct()
        {
            return new Product()
            {
                Weight = Convert.ToDouble(txtWeight.Text),
                Length = Convert.ToDouble(txtLength.Text),
                Width = Convert.ToDouble(txtWidth.Text),
                Height = Convert.ToDouble(txtHeight.Text),
            };
        }
    }

    public class PostOffice : ILogistics
    {
        private readonly string _companyName = "郵局";
        private double _fee = 0;
        public Product ShipProduct { get; set; }

        public void Calculated()
        {
            //lblLogistics.Text = ddlLogistics.SelectedItem.Text;

            //var weight = Convert.ToDouble(txtWeight.Text);
            //var feeByWeight = 80 + (weight * 10);

            //var width = Convert.ToDouble(txtWidth.Text);
            //var length = Convert.ToDouble(txtLength.Text);
            //var height = Convert.ToDouble(txtHeight.Text);

            //var size = width * length * height;
            //var feeBySize = size * 0.0000353 * 1100;

            //if (feeByWeight < feeBySize)
            //{
            //    lblFee.Text = feeByWeight.ToString("C");
            //}
            //else
            //{
            //    lblFee.Text = feeBySize.ToString("C");
            //}

            var weight = ShipProduct.Weight; ;
            var feeByWeight = 80 + (weight * 10);

            var width = ShipProduct.Width;
            var length = ShipProduct.Length;
            var height = ShipProduct.Height;

            var size = width * length * height;
            var feeBySize = size * 0.0000353 * 1100;

            if (feeByWeight < feeBySize)
            {
                _fee = feeByWeight;
            }
            else
            {
                _fee = feeBySize;
            }
        }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public double GetFee()
        {
            return _fee;
        }
    }

    public class Hsinchu : ILogistics
    {
        private readonly string _companyName = "新竹貨運";
        private double _fee = 0;

        public void Calculated()
        {
            //lblLogistics.Text = ddlLogistics.SelectedItem.Text;

            //var width = Convert.ToDouble(txtWidth.Text);
            //var length = Convert.ToDouble(txtLength.Text);
            //var height = Convert.ToDouble(txtHeight.Text);

            //var size = (width * length * height);

            //if (length > 100 || width > 100 || height > 100)
            //{
            //    lblFee.Text = (size * 0.0000353 * 1100 + 500).ToString("C");
            //}
            //else
            //{
            //    lblFee.Text = (size * 0.0000353 * 1200).ToString("C");
            //}

            var width = ShipProduct.Width;
            var length = ShipProduct.Length;
            var height = ShipProduct.Height;

            var size = (width * length * height);

            if (length > 100 || width > 100 || height > 100)
            {
                _fee = (size * 0.0000353 * 1100 + 500);
            }
            else
            {
                _fee = (size * 0.0000353 * 1200);
            }
        }

        public Product ShipProduct { get; set; }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public double GetFee()
        {
            return _fee;
        }
    }

    public interface ILogistics
    {
        void Calculated();
        string GetCompanyName();
        double GetFee();
        Product ShipProduct { get; set; }
    }

    public class BlackCat : ILogistics
    {
        private readonly string _companyName = "黑貓";
        private double _fee = 0d;

        public void Calculated()
        {
            //lblLogistics.Text = ddlLogistics.SelectedItem.Text;

            //var weight = Convert.ToDouble(txtWeight.Text);

            //if (weight > 20)
            //{
            //    lblFee.Text = 500.ToString("C");
            //}
            //else
            //{
            //    lblFee.Text = (100 + weight * 10).ToString("C");
            //}

            var weight = ShipProduct.Weight;

            if (weight > 20)
            {
                _fee = 500;
            }
            else
            {
                _fee = (100 + weight * 10);
            }
        }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public double GetFee()
        {
            return _fee;
        }

        public Product ShipProduct { get; set; }
    }

    public class Product
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}