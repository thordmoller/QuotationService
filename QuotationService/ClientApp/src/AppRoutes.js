import { Home } from "./components/Home";
import { QuotationService } from "./components/QuotationService";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/offert',
    element: <QuotationService />
  }
];

export default AppRoutes;
