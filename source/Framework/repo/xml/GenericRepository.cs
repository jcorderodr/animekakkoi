using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;

namespace Framework.repo.xml
{
    public class GenericRepository //: Repository<entity.EntitySource>
    {

        [Obsolete]
        private void SwitchElements(Type type, string values, string progress)
        {
            //TODO: kokoni
        }

        //public override entity.EntitySource Add(entity.EntitySource item)
        //{
        //    throw new NotImplementedException();
        //}

        //public override int AddRange(IList<entity.EntitySource> items)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Change(entity.EntitySource item)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Remove(entity.EntitySource item)
        //{
        //    throw new NotImplementedException();
        //}

        //public override IList<entity.EntitySource> GetAll()
        //{
        //    List<object> list;

        //    //base.
        //    return null;
        //}



        //internal override entity.EntitySource ToEntity(System.Xml.Linq.XElement item)
        //{
        //    throw new NotImplementedException();
        //}

        //internal override System.Xml.Linq.XElement ToData(entity.EntitySource item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
