import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import Create from "./components/Create";
import Delete from "./components/Delete";
import Display from "./components/Display";
import Update from "./components/Update";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/create',
        element: <Create />
    },
    {
        path: '/delete',
        element: <Delete />
    },
    {
        path: '/display',
        element: <Display />
    },
    {
        path: '/update',
        element: <Update />
    }
];

export default AppRoutes;
