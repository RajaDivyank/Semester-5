import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

export default function AddEditComponent() {
  const [data, setData] = useState({});
  const navigate = useNavigate();
  const param = useParams();
  const apiUrl = "https://64e1bfd7ab00373588186085.mockapi.io/students";
  useEffect(() => {
    if (param.id > 0) {
      fetch(apiUrl + "/" + param.id)
        .then((res) => {
          return res.json();
        })
        .then((res) => {
          setData(res);
        });
    }
  }, []);
  return (
    <>
      <label class="form-label">Student Name</label>
      <input
        type="text"
        class="form-control"
        value={data.StudentName}
        onChange={(e) => {
          setData({ ...data, StudentName: e.target.value });
        }}
      />
      <button
        onClick={() => {
          if (param.id > 0) {
            fetch(apiUrl + "/" + param.id, {
              method: "PUT",
              body: JSON.stringify(data),
              headers: { "Content-Type": "application/json" },
            }).then((res) => {
              navigate("/");
            });
          } else {
            fetch(apiUrl, {
              method: "POST",
              body: JSON.stringify(data),
              headers: { "Content-Type": "application/json" },
            }).then((res) => {
              navigate("/");
            });
          }
        }}
      >
        Submit
      </button>
    </>
  );
}
