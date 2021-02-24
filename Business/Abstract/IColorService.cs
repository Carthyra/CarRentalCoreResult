using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> Get(int colorId);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);

    }
}
