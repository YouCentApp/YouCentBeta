﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Fast.Components.FluentUI.Utilities;

namespace BlazorSite.Shared;

public partial class NavMenuGroup : FluentComponentBase
{
    private bool _expanded = false;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    /// <summary>
    /// Gets or sets the content to be rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the destination of the link.
    /// </summary>
    [Parameter]
    public string? Href { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the name of the icon to display with the link
    /// </summary>
    [Parameter]
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// Icon displayed only when the <see cref="NavMenu.Expanded"/> is false.
    /// </summary>
    [Parameter]
    public string IconNavMenuCollapsed { get; set; } = FluentIcons.MoreHorizontal;

    /// <summary>
    /// Gets or sets a unique identifier.
    /// </summary>
    [Parameter]
    public string Id { get; set; } = Identifier.NewId();

    /// <summary>
    /// Gets or sets whether the menu group is disabled
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }
    
   
    /// <summary>
    /// Gets or sets whether the menu group is expanded
    /// </summary>
    [Parameter]
    public bool Expanded { get; set; }

    /// <summary>
    /// Gets or sets whether the menu group is selected
    /// </summary>
    [Parameter]
    public bool Selected { get; set; }

    /// <summary>
    /// Gets or sets the text of the menu group
    /// </summary>
    [Parameter]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the width of the menu group
    /// </summary>
    [Parameter]
    public int? Width { get; set; }
    
    /// <summary>
    /// Callback function for when the menu group is expanded
    /// </summary>
    [Parameter]
    public EventCallback<bool> OnExpandedChanged { get; set; }
 

    [CascadingParameter(Name = "NavMenu")]
    public NavMenu NavMenu { get; set; } = default!;

    [CascadingParameter(Name = "NavMenuExpanded")]
    private bool NavMenuExpanded { get; set; }


    protected string? ClassValue => new CssBuilder(Class)
        .AddClass("navmenu-group")
        .Build();

    protected string? StyleValue => new StyleBuilder()
        .AddStyle("width", $"{Width}px", () => Width.HasValue)
        .AddStyle(Style)
        .Build();

    private bool HasIcon => !string.IsNullOrWhiteSpace(Icon);

    protected override void OnParametersSet()
    {
        NavMenu.AddNavMenuGroup(this);

        if (_expanded != Expanded)
        {
            _expanded = Expanded;
            if (OnExpandedChanged.HasDelegate)
                OnExpandedChanged.InvokeAsync(_expanded);
        }
    }



    /// <summary />
    internal async Task ExpandMenu()
    {
        if (Disabled)
            return;

        // Expand the Menu Group if the user click on it
        if (!NavMenuExpanded)
        {
            Selected = true;
            await NavMenu.CollapsibleClickAsync();
        }
    }

    internal void HandleIconClick()
    {
        if (!Disabled)
            Selected = true;
    }
}
