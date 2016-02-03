using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SelectServiceServiceReference1.SelectServiceServiceClient db = new SelectServiceServiceReference1.SelectServiceServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDownListArtist();
            LoadDropDownListVenue();
        }
        
    }

    protected void DropDownListArtist_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGridArtist();
    }

    protected void LoadDropDownListArtist()
    {
        string[] artists = db.GetArtists();
        DropDownListArtist.DataSource = artists;
        DropDownListArtist.DataBind();
        DropDownListArtist.Items.Insert(0, "Choose an Artist");

    }

    protected void FillGridArtist()
    {
        string artist = DropDownListArtist.SelectedItem.Text;
        SelectServiceServiceReference1.ShowLite[] shows = db.GetShowByArtist(artist);
        GridViewShow1.DataSource = shows;
        GridViewShow1.DataBind();
    }

    protected void DropDownListVenue_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGridVenue();
    }

    protected void LoadDropDownListVenue()
    {
        string[] venues = db.GetVenues();
        DropDownListVenue.DataSource = venues;
        DropDownListVenue.DataBind();
        DropDownListVenue.Items.Insert(0, "Choose a Venue");

    }

    protected void FillGridVenue()
    {
        string venue = DropDownListVenue.SelectedItem.Text;
        SelectServiceServiceReference1.ShowLite[] shows = db.GetShowByVenue(venue);
        GridViewShow1.DataSource = shows;
        GridViewShow1.DataBind();
    }
}