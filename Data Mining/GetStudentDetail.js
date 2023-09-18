import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";

export default function GetStudentDetail() {
  const [data, setData] = useState({});
  const navigate = useNavigate();
  const param = useParams();
  const apiUrl = "https://64e1bfd7ab00373588186085.mockapi.io/students";
  useEffect(() => {
    fetch(apiUrl + "/" + param.id)
      .then((res) => {
        return res.json();
      })
      .then((res) => {
        setData(res);
      });
  }, []);
  return (
    <div className="card" style={{ width: "18rem", textAlign: "center" }}>
      <img src={data.StudentImage} className="card-img-top" />
      <div className="card-body">
        <h5 className="card-title">{data.StudentName}</h5>
        <p className="card-text">{data.StudentEmail}</p>
        <p className="card-text">{data.StudentAddress}</p>
        <button
          className="btn btn-primary m-2"
          onClick={() => {
            navigate("/");
          }}
        >
          Back
        </button>
        <Link to={"/edit/" + param.id}>
          <button className="btn btn-success m-2">Edit</button>
        </Link>
      </div>
    </div>
  );
}
