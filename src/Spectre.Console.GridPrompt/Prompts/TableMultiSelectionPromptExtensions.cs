namespace Spectre.Console;

/// <summary>
/// Contains extension methods for <see cref="TableMultiSelectionPrompt{T}"/>.
/// </summary>
public static class TableMultiSelectionPromptExtensions
{
    /// <summary>
    /// Sets the selection mode.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="mode">The selection mode.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> Mode<T>(this TableMultiSelectionPrompt<T> obj, SelectionMode mode)
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
    /// Adds a choice.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="choice">The choice to add.</param>
    /// <param name="configurator">The configurator for the choice.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> AddChoices<T>(this TableMultiSelectionPrompt<T> obj, T choice, Action<IMultiSelectionItem<T>> configurator)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        if (configurator is null)
        {
            throw new ArgumentNullException(nameof(configurator));
        }

        var result = obj.AddChoice(choice);
        configurator(result);

        return obj;
    }

    /// <summary>
    /// Adds multiple choices.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="choices">The choices to add.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> AddChoices<T>(this TableMultiSelectionPrompt<T> obj, params T[] choices)
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
    public static TableMultiSelectionPrompt<T> AddChoices<T>(this TableMultiSelectionPrompt<T> obj, IEnumerable<T> choices)
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
    public static TableMultiSelectionPrompt<T> AddChoiceGroup<T>(this TableMultiSelectionPrompt<T> obj, T group, IEnumerable<T> choices)
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
    public static TableMultiSelectionPrompt<T> AddChoiceGroup<T>(this TableMultiSelectionPrompt<T> obj, T group, params T[] choices)
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
    /// Marks an item as selected.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="item">The item to select.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> Select<T>(this TableMultiSelectionPrompt<T> obj, T item)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        var node = obj.Tree.Find(item);
        node?.Select();

        return obj;
    }

    /// <summary>
    /// Sets the title.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="title">The title markup text.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> Title<T>(this TableMultiSelectionPrompt<T> obj, string? title)
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
    public static TableMultiSelectionPrompt<T> PageSize<T>(this TableMultiSelectionPrompt<T> obj, int pageSize)
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
    public static TableMultiSelectionPrompt<T> WrapAround<T>(this TableMultiSelectionPrompt<T> obj, bool shouldWrap = true)
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
    /// Sets the highlight style of the selected choice.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="highlightStyle">The highlight style of the selected choice.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> HighlightStyle<T>(this TableMultiSelectionPrompt<T> obj, Style highlightStyle)
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
    public static TableMultiSelectionPrompt<T> MoreChoicesText<T>(this TableMultiSelectionPrompt<T> obj, string? text)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.MoreChoicesText = text;
        return obj;
    }

    /// <summary>
    /// Sets the text that instructs the user of how to select items.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="text">The text to display.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> InstructionsText<T>(this TableMultiSelectionPrompt<T> obj, string? text)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.InstructionsText = text;
        return obj;
    }

    /// <summary>
    /// Requires no choice to be selected.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> NotRequired<T>(this TableMultiSelectionPrompt<T> obj)
        where T : notnull
    {
        return Required(obj, false);
    }

    /// <summary>
    /// Requires a choice to be selected.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> Required<T>(this TableMultiSelectionPrompt<T> obj)
        where T : notnull
    {
        return Required(obj, true);
    }

    /// <summary>
    /// Sets a value indicating whether or not at least one choice must be selected.
    /// </summary>
    /// <typeparam name="T">The prompt result type.</typeparam>
    /// <param name="obj">The prompt.</param>
    /// <param name="required">Whether or not at least one choice must be selected.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static TableMultiSelectionPrompt<T> Required<T>(this TableMultiSelectionPrompt<T> obj, bool required)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.Required = required;
        return obj;
    }

    public static TableMultiSelectionPrompt<T> UseConfigureTable<T>(this TableMultiSelectionPrompt<T> obj, Action<Table> configureTable)
        where T : notnull
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.ConfigureTable = configureTable;
        return obj;
    }

    public static TableMultiSelectionPrompt<T> AddColumn<T>(this TableMultiSelectionPrompt<T> obj, string header, Func<T, string> valueGetter, Action<TableColumn>? configure = null)
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