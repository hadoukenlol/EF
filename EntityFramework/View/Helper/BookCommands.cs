using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.View.Helper
{
    public enum BookCommands
    {
        stop,
        findById,
        add,
        delete,
        updateName,
        showAll,
        hasBookByNameAndAuthorInLib,
        hasBookByNameAndAuthorInUser,
        showLast,
        showAllAscSortByName,
        showAllDescSortByPublishYear

    }

}
