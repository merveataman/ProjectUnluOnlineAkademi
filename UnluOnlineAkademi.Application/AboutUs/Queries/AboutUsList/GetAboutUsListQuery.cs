using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList
{
    public class GetAboutUsListQuery: IRequest<List<AboutUsDto>>
    {
    }
}
