import ReactDOM from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import LayoutComponent from "./LayoutComponent";
import GetAllStudent from "./GetAllStudent";
import GetStudentDetail from "./GetStudentDetail";
import AddEditComponent from "./AddEditComponent";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<LayoutComponent />}>
        <Route index element={<GetAllStudent />}></Route>
        <Route path="/:id" element={<GetStudentDetail />}></Route>
        <Route path="/add" element={<AddEditComponent />}></Route>
        <Route path="/edit/:id" element={<AddEditComponent />}></Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
