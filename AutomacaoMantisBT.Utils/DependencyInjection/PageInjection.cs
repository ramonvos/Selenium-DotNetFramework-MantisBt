using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AutomacaoMantisBT.Utils.DependencyInjection
{
    //public class PageInjection
    //{
    //    private ProxyGenerator ProxyGenerator;

    //    public PageInjection()
    //    {
    //        this.ProxyGenerator = new ProxyGenerator();
    //        InjectPageObjects(CollectPageObjects(), null);
    //    }


    //    public void InjectPageObjects(List<FieldInfo> fields, IInterceptor proxy)
    //    {
    //        foreach (FieldInfo field in fields)
    //        {
    //            field.SetValue(this, ProxyGenerator.CreateClassProxy(field.FieldType, proxy));
    //        }
    //    }

    //    private List<FieldInfo> CollectPageObjects()
    //    {
    //        List<FieldInfo> fields = new List<FieldInfo>();

    //        foreach (FieldInfo field in this.GetType().GetRuntimeFields())
    //        {
    //            if (field.GetCustomAttribute(typeof(PageObject)) != null)
    //                fields.Add(field);
    //        }

    //        return fields;
    //    }

    //}
}
