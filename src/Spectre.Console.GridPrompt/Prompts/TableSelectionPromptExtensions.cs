namespace Spectre.Console;

/// <summary>
/// Contains extension methods for <see cref="SelectionPrompt{T}"/>.
/// </summary>
public static class TableSelectionPromptExtensions
{
    /// <summary>
    /// Sets the selection mode.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="mode">The selection mode.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> Mode<T>(this TableSelectionPrompt<T> obj, SelectionMode mode)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.Mode = mode;
        return obj;
    }

    /// <summary>
    /// Adds multiple choices.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="choices">The choices to add.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> AddChoices<T>(this TableSelectionPrompt<T> obj, params T[] choices)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        foreach (var choice in choices)
        {
            obj.AddChoice(choice);
        }

        return obj;
    }

    /// <summary>
    /// Adds multiple choices.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="choices">The choices to add.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> AddChoices<T>(this TableSelectionPrompt<T> obj, IEnumerable<T> choices)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        foreach (var choice in choices)
        {
            obj.AddChoice(choice);
        }

        return obj;
    }

    /// <summary>
    /// Adds multiple grouped choices.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="group">The group.</param>
    /// <param name="choices">The choices to add.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> AddChoiceGroup<T>(this TableSelectionPrompt<T> obj, T group, IEnumerable<T> choices)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        var root = obj.AddChoice(group);
        foreach (var choice in choices)
        {
            root.AddChild(choice);
        }

        return obj;
    }

    /// <summary>
    /// Adds multiple grouped choices.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="group">The group.</param>
    /// <param name="choices">The choices to add.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> AddChoiceGroup<T>(this TableSelectionPrompt<T> obj, T group, params T[] choices)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        var root = obj.AddChoice(group);
        foreach (var choice in choices)
        {
            root.AddChild(choice);
        }

        return obj;
    }

    /// <summary>
    /// Sets the title.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="title">The title markup text.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> Title<T>(this TableSelectionPrompt<T> obj, string? title)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.Title = title;
        return obj;
    }

    /// <summary>
    /// Sets how many choices that are displayed to the user.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="pageSize">The number of choices that are displayed to the user.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> PageSize<T>(this TableSelectionPrompt<T> obj, int pageSize)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        if (pageSize <= 2)
        {
            throw new ArgumentException("Page size must be greater or equal to 3.", nameof(pageSize));
        }

        obj.PageSize = pageSize;
        return obj;
    }

    /// <summary>
    /// Sets whether the selection should wrap around when reaching its edges.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="shouldWrap">Whether the selection should wrap around.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> WrapAround<T>(this TableSelectionPrompt<T> obj, bool shouldWrap = true)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.WrapAround = shouldWrap;
        return obj;
    }

    /// <summary>
    /// Enables search for the prompt.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> EnableSearch<T>(this TableSelectionPrompt<T> obj)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.SearchEnabled = true;
        return obj;
    }

    /// <summary>
    /// Disables search for the prompt.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> DisableSearch<T>(this TableSelectionPrompt<T> obj)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.SearchEnabled = false;
        return obj;
    }

    /// <summary>
    /// Sets the text that will be displayed when no search text has been entered.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="text">The text to display.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> SearchPlaceholderText<T>(this TableSelectionPrompt<T> obj, string? text)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.SearchPlaceholderText = text;
        return obj;
    }

    /// <summary>
    /// Sets the highlight style of the selected choice.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="highlightStyle">The highlight style of the selected choice.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> HighlightStyle<T>(this TableSelectionPrompt<T> obj, Style highlightStyle)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.HighlightStyle = highlightStyle;
        return obj;
    }

    /// <summary>
    /// Sets the text that will be displayed if there are more choices to show.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="text">The text to display.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableSelectionPrompt<T> MoreChoicesText<T>(this TableSelectionPrompt<T> obj, string? text)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.MoreChoicesText = text;
        return obj;
    }

    public static TableSelectionPrompt<T> UseConfigureTable<T>(this TableSelectionPrompt<T> obj, Action<Table> configureTable)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.ConfigureTable = configureTable;
        return obj;
    }

    public static TableSelectionPrompt<T> AddColumn<T>(this TableSelectionPrompt<T> obj, string header, Func<T, string> valueGetter, Action<TableColumn>? configure = null)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.Columns.Add(new SelectionTableColumn<T>(header, valueGetter, configure));
        return obj;
    }
}