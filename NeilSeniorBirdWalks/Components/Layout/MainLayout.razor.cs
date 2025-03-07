using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using MudBlazor;
using static MudBlazor.CategoryTypes;

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
            Typography = new Typography()
            {
                Default = new DefaultTypography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "1rem",
                    FontWeight = "400",
                    LineHeight = "1.5",
                    LetterSpacing = ".00938em"
                },
                H1 = new H1Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "2.5rem",
                    FontWeight = "500",
                    LineHeight = "1.2",
                    LetterSpacing = "-.01562em"
                },
                H2 = new H2Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "2rem",
                    FontWeight = "500",
                    LineHeight = "1.3",
                    LetterSpacing = "-.00833em"
                },
                H3 = new H3Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "1.75rem",
                    FontWeight = "500",
                    LineHeight = "1.35",
                    LetterSpacing = "0"
                },
                H4 = new H4Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "1.5rem",
                    FontWeight = "500",
                    LineHeight = "1.4",
                    LetterSpacing = ".00735em"
                },
                H5 = new H5Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "1.25rem",
                    FontWeight = "500",
                    LineHeight = "1.5",
                    LetterSpacing = "0"
                },
                H6 = new H6Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "1.125rem",
                    FontWeight = "500",
                    LineHeight = "1.6",
                    LetterSpacing = ".0075em"
                },
                Button = new ButtonTypography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "0.875rem",
                    FontWeight = "500",
                    LineHeight = "1.75",
                    LetterSpacing = ".02857em"
                },
                Body1 = new Body1Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "1rem",
                    FontWeight = "400",
                    LineHeight = "1.5",
                    LetterSpacing = ".00938em"
                },
                Body2 = new Body2Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "0.875rem",
                    FontWeight = "400",
                    LineHeight = "1.43",
                    LetterSpacing = ".01071em"
                },
                Caption = new CaptionTypography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "0.75rem",
                    FontWeight = "400",
                    LineHeight = "1.66",
                    LetterSpacing = ".03333em"
                },
                Subtitle1 = new Subtitle1Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "1rem",
                    FontWeight = "500",
                    LineHeight = "1.57",
                    LetterSpacing = ".00714em"
                },
                Subtitle2 = new Subtitle2Typography()
                {
                    FontFamily = new[] { "Source Sans 3", "sans-serif" },
                    FontSize = "0.875rem",
                    FontWeight = "500",
                    LineHeight = "1.57",
                    LetterSpacing = ".00714em"
                }
            },

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
