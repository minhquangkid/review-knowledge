import { useEffect, useState } from "react";
import Middle from "./Middle.jsx";
import { Link } from "react-router-dom";

function HomePage(props) {
  const [data, setData] = useState("");

  useEffect(() => {
    fetch("https://localhost:7000/api/home/init")
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
      });
  }, []);

  const getData = (newData) => {
    setData(newData);
  };

  return (
    <div>
      <h1>Home page</h1>
      <p>{props.content}</p>

      <p>This below is child content</p>
      <p>{data}</p>
      <br />
      <Middle callBack={getData} />
      <Link to="/contact">Go to Contact page</Link>
    </div>
  );
}

export default HomePage;
