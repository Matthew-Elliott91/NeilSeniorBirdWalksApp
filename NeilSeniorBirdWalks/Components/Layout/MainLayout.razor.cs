using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using MudBlazor;

namespace NeilSeniorBirdWalks.Components.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] private NavigationManager NavigationManager { get; set; }


        // Drawer
        private bool _drawerOpen = false;

        private void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }


        //Theme
        MudTheme _neilSeniorTheme = new()
        {
            PaletteLight = new PaletteLight()
            {
                AppbarBackground = new MudColor("#5885af"),
                Primary = new MudColor("#274472"),
                Secondary = new MudColor("#41729f"),
                Tertiary = new MudColor("#5885af"),
                Background = new MudColor("#c3e0e5"),
                Surface = new MudColor("#DAD7CD"),
                ActionDefault = new MudColor("#3E5E3E"),
                Success = new MudColor("#6A994E"),
                Warning = new MudColor(" #E9B44C"),
                Error = new MudColor("#A63D40"),
                Info = new MudColor("#5B8DB3"),
                TextPrimary = new MudColor("#2C3E50"),
                TextSecondary = new MudColor("#4C7C4C"),
                Black = new MudColor("#000000"),
                White = new MudColor("#FFFFFF")

            },
            PaletteDark = new PaletteDark()
            {
                AppbarBackground = new MudColor("#424242ff"),
                Primary = new MudColor("#FFFFFF"),
                Secondary = new MudColor("#48D1CC"),
            },
            LayoutProperties = new LayoutProperties()
            {
                AppbarHeight = "70px"
            }


        };
    }
}
