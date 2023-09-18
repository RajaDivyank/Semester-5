import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

export default function GetAllStudent() {
  const [data, setData] = useState([]);
  const navigate = useNavigate();
  const apiUrl = "https://64e1bfd7ab00373588186085.mockapi.io/students";
  useEffect(() => {
    fetch(apiUrl)
      .then((res) => {
        return res.json();
      })
      .then((res) => {
        setData(res);
      });
  }, []);
  const formatedStudent = data.map((stu) => {
    return (
      <div className="card col-3" style={{ width: "18rem" }}>
        <img src={stu.StudentImage} className="card-img-top" alt="..." />
        <div className="card-body">
          <h5 className="card-title">{stu.StudentName}</h5>
          <p className="card-text">{stu.StudentEmail}</p>
          <p className="card-text">{stu.StudentAddress}</p>
          <button
            className="btn btn-primary m-2"
            onClick={() => {
              navigate("/" + stu.id);
            }}
          >
            Detail
          </button>
          <button
            className="btn btn-danger m-2"
            onClick={() => {
              fetch(apiUrl + "/" + stu.id, { method: "DELETE" });
              setData(
                data.filter((e) => {
                  return e.id !== stu.id;
                })
              );
            }}
          >
            Delete
          </button>
        </div>
      </div>
    );
  });
  return <div className="row">{formatedStudent}</div>;
}
