using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                if ("1".Equals(ddlLogistics.SelectedValue))
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
                else if ("2".Equals(ddlLogistics.SelectedValue))
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
                else if ("3".Equals(ddlLogistics.SelectedValue))
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
            }
        }
    }
}