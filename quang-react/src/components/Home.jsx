import { useState } from "react";
import Middle from "./Middle.jsx";
import { Link } from "react-router-dom";

function HomePage(props) {
  const [data, setData] = useState("");

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
