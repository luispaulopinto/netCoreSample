using Sample.Application.Responses;

namespace Sample.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse()
            : base() { }

        public CreateCategoryDto Category { get; set; } = default!;
    }
}
