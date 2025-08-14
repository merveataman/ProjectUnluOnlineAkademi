using MediatR;

namespace UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentGetList
{
    public class GetEducationalContentListQuery:IRequest<List<EducationalContentDto>>
    {
    }
}
