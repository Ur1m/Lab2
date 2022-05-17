using System;
using System.ComponentModel.DataAnnotations;
using Play.Products.Service.Enteties;

namespace Products.Service.Dtos
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    public record CreateItemDto([Required] string Name, string Description, [Range(0, 10000)] decimal Price);

    public record UpdateItemDto([Required] string Name, string Description, [Range(0, 10000)] decimal Price);
    public record CategoryDTO( int CategoryId, string Name,string Description,string Image, int DisplayOrder, bool IsDeleted
	);
    public record CourseDTO(int CourseId,string Name,string Description,string Image,int Difficulty,string CourseContent,DateTime CreatedOn,bool IsDeleted,int CategoryId,Category Category);
    public record AttributeDTO(int AttributeId,string Name);


}