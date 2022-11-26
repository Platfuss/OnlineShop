import React from "react";

const Img64Base = ({ src, alt = "", innerRef, ...props }) => {
  return (
    <img
      src={`data:image/jpg;base64,${src}`}
      alt={alt}
      ref={innerRef}
      {...props}
    />
  );
};

export default Img64Base;
