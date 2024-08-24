import { useState } from "react";
import Middle from "./Middle.jsx";

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
      <Middle callBack={getData}></Middle>
    </div>
  );
}

export default HomePage;
