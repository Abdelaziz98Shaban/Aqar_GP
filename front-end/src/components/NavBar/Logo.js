import React from "react";
import { Text } from "@chakra-ui/react";

import { useBreakpointValue, useColorModeValue } from "@chakra-ui/react";

const Logo = props => {
  return (
    <Text
      textAlign={useBreakpointValue({ base: "center", md: "left" })}
      fontFamily={"heading"}
      fontSize='lg'
      fontWeight='bold'
      color={useColorModeValue("gray.800", "white")}
    >
      {props.title || props.children}
    </Text>
  );
};
export default Logo;
