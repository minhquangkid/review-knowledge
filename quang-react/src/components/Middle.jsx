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

      <input type="text" value={inputData} onChange={handleChange} />
      <button
        onClick={() => {
          props.callBack(inputData);
        }}
      >
        Send back to father
      </button>
    </React.Fragment>
  );
};

export default Middle;
