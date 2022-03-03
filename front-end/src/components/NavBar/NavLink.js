import React from "react";

import { Text, Box, useColorModeValue } from "@chakra-ui/react";

import { Link as RouterLink } from "react-router-dom";

const NavLink = ({ children, herf }) => (
  <Box>
    <RouterLink to={herf}>
      <Text
        px={2}
        py={1}
        rounded={"md"}
        outline='none'
        border='none'
        _hover={{
          textDecoration: "none",
          bg: useColorModeValue("gray.200", "gray.700"),
        }}
      >
        {children}
      </Text>
    </RouterLink>
  </Box>
);

export default NavLink;
