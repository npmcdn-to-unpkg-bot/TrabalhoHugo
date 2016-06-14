using System;
using System.Reflection;

namespace Si.Dev.Uniplac.TrabalhoSC.API.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}