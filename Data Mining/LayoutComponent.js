import { Link, Outlet } from "react-router-dom";

export default function LayoutComponent() {
  return (
    <>
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
          <Link to="/" class="navbar-brand btn btn-primary">
            All Student
          </Link>
        </div>
        <div class="container-fluid">
          <Link class="navbar-brand btn btn-primary" to="/add">
            Add Student
          </Link>
        </div>
      </nav>
      <Outlet />
    </>
  );
}
