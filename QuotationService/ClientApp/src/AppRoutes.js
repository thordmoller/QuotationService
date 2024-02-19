import CityList from "./components/CityList";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { QuotationService } from "./components/QuotationService";

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
    path: '/offert',
    element: <QuotationService />
  },
  {
    path: '/citylist',
    element: <CityList />
  }
];

export default AppRoutes;
