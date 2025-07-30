using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.AboutUs.Queries
{
    public class GetAboutUsListQuery: IRequest<List<AboutUsDto>>
    {
    }
}
