using System;

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

                if ("1".Equals(ddlLogistics.SelectedValue))
                {
                    //CalculatedByBlackCat();

                    var blackCat = new BlackCat() {ShipProduct = product};
                    blackCat.Calculated();

                    var companyName = blackCat.GetCompanyName();
                    var fee = blackCat.GetFee();
                }
                else if ("2".Equals(ddlLogistics.SelectedValue))
                {
                    //CalculateHsinchu();

                    var hsinchu = new Hsinchu() { ShipProduct = product};
                    hsinchu.Calculated();

                    var companyName = hsinchu.GetCompanyName();
                    var fee = hsinchu.GetFee();
                }
                else if ("3".Equals(ddlLogistics.SelectedValue))
                {
                    //CalculatedByPostOffice();
                    var postOffice = new PostOffice();
                    postOffice.Calculated();

                    var companyName = postOffice.GetCompanyName();
                    var fee = postOffice.GetFee();
                }
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

    public class PostOffice
    {
        public void Calculated()
        {
            throw new NotImplementedException();
        }

        public string GetCompanyName()
        {
            throw new NotImplementedException();
        }

        public double GetFee()
        {
            throw new NotImplementedException();
        }
    }

    public class Hsinchu
    {
        public void Calculated()
        {
            throw new NotImplementedException();
        }

        public Product ShipProduct { get; set; }

        public string GetCompanyName()
        {
            throw new NotImplementedException();
        }

        public double GetFee()
        {
            throw new NotImplementedException();
        }
    }

    public class BlackCat
    {
        private readonly string _companyName = "黑貓";

        public void Calculated()
        {
            throw new NotImplementedException();
        }
        
        public string GetCompanyName()
        {
            return _companyName;
        }

        public double GetFee()
        {
            throw new NotImplementedException();
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