import React, { useRef, useState } from "react";

// class Middle extends React.Component {
//   constructor(props) {
//     super(props);
//     this.state = { inputValue: "" };
//   }

//   title = "nothing here";
//   updateInput() {
//     this.setState({ inputValue: this.title });
//   }

//   render() {
//     return (
//       <React.Fragment>
//         <input type="text" value={this.title} onChange={this.updateInput()} />
//         <button
//           onClick={() => {
//             this.props.callBack(this.state.inputValue);
//           }}
//         >
//           Send back to father
//         </button>
//       </React.Fragment>
//     );
//   }
// }

const Middle = (props) => {
  const [inputData, setInputData] = useState("nothing here");

  //   const inputRef = useRef("nothing here");

  //   const show = () => {
  //     console.log(inputRef.current.value);
  //   };
  function handleChange(event) {
    setInputData(event.target.value);
  }

  function createCustomer() {
    var customer = {
      CustomerID: inputData,
      CompanyName: "quang",
    };

    fetch("https://localhost:7000/api/home/add-customer", {
      method: "POST",
      headers: {
        "Content-type": "Application/json",
      },
      body: JSON.stringify(customer),
    })
      .then((r) => r.json())
      .then((e) => {
        console.log(e);
      });
  }

  return (
    <React.Fragment>
      {/* <input type="text" ref={inputRef} />
      <button
        onClick={() => {
          props.callBack(inputRef.current.value);
        }}
      >
        Send back to father
      </button> */}

      <input
        type="text"
        value={inputData}
        onChange={handleChange}
        maxLength={5}
      />
      <br />
      <button
        onClick={() => {
          props.callBack(inputData);
        }}
      >
        Send back to father and DB
      </button>
      <br />
      <button onClick={createCustomer}>Create Customer</button>
      <br />
    </React.Fragment>
  );
};

export default Middle;
