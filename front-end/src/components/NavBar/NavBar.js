import React from "react";
import {
  Box,
  Flex,
  Button,
  HStack,
  Stack,
  useColorModeValue,
  useColorMode,
  useDisclosure,
} from "@chakra-ui/react";

import { MoonIcon, SunIcon } from "@chakra-ui/icons";

import Logo from "./Logo";
import MenuToggler from "./MenuToggler";
import DesktopNav from "./DesktopNav";
import MobileNav from "./MobileNav";

const Links = [
  { path: "/", content: "Home" },
  { path: "/search", content: "Search" },
  { path: "/property", content: "Properties" },
];

const NavBar = () => {
  const { colorMode, toggleColorMode } = useColorMode();
  const { isOpen, onOpen, onClose } = useDisclosure();

  return (
    <>
      <Box bg={useColorModeValue("gray.100", "gray.900")} px={4}>
        <Flex h={16} alignItems={"center"} justifyContent={"space-between"}>
          <MenuToggler isOpen={isOpen} onOpen={onOpen} onClose={onClose} />
          <HStack spacing={8} alignItems={"center"}>
            <Logo title='Aqar' />

            <DesktopNav items={Links} />
          </HStack>
          <Flex alignItems={"center"}>
            <Stack
              flex={{ base: 1, md: 0 }}
              justify={"flex-end"}
              direction={"row"}
              spacing={6}
            >
              <Button
                display={{ base: "none", md: "flex" }}
                onClick={toggleColorMode}
              >
                {colorMode === "light" ? <MoonIcon /> : <SunIcon />}
              </Button>
              <Button
                fontSize={"sm"}
                fontWeight={400}
                variant={"link"}
                onClick={() => console.log("Sign in")}
              >
                Sign In
              </Button>
              <Button
                display={{ base: "none", md: "flex" }}
                fontSize={"sm"}
                fontWeight={600}
                color={"white"}
                bg={"teal.400"}
                onClick={() => console.log("Sign Up")}
                _hover={{
                  bg: "teal.300",
                }}
              >
                Sign Up
              </Button>
            </Stack>
          </Flex>
        </Flex>

        {isOpen ? (
          <Box display={{ md: "none" }}>
            <MobileNav
              items={Links}
              colorMode={colorMode}
              toggleColorMode={toggleColorMode}
            />
          </Box>
        ) : null}
      </Box>
    </>
  );
};

export default NavBar;
