﻿namespace Bakasov.Core.Entities;

/// <summary>
/// Class Product.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>The price.</value>
    public decimal Price { get; set; }



    public int BrandId { get; set;}


    public int SizeId { get; set;}


    public int CategoryId { get; set;}
}