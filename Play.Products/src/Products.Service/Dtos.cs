using System;
using System.ComponentModel.DataAnnotations;
using Play.Products.Service.Enteties;

namespace Products.Service.Dtos
{
    //----------------------- Items ------------------------------------------
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate, Category CategoryId);

    public record CreateItemDto([Required] string Name, string Description, [Range(0, 10000)] decimal Price, Category CategoryId);

    public record UpdateItemDto([Required] string Name, string Description, [Range(0, 10000)] decimal Price, Category CategoryId);
    //----------------------- Category ------------------------------------------
    public record CategoryDto(Guid Id, string Name, string Description);

    public record CreateCategoryDto([Required] string Name, string Description);

    public record UpdateCategoryDto([Required] string Name, string Description);
    //----------------------- Reviews ------------------------------------------
    public record ReviewsDto(Guid Id, string Comment, Items ItemsId);

    public record CreateReviewsDto(string Comment, Items ItemsId);

    public record UpdateReviewsDto(string Comment, Items ItemsId);


}