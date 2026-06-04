# Less Stupid Romance Attempt (Continued) - GitHub Copilot Instructions

## Mod Overview and Purpose
The "Less Stupid Romance Attempt (Continued)" mod is an updated version of the original mod by Dazz Aephiex designed for RimWorld v1.0. Its primary objective is to refine the romance interaction mechanics of the game to be more realistic and logical. By addressing several common-sense scenarios, the mod aims to enhance player immersion and align character behaviors with expected social norms.

## Key Features and Systems
1. **Deterrance of Improper Romance Attempts**: 
   - Characters in a stable relationship (+25 or greater opinion) cannot perform or be targeted by a new romance attempt.
   - Recently rebuffed characters (as indicated by a mood modifier) will not engage in or accept new romance attempts.

2. **Sexual Orientation Considerations**:
   - Optimizes romantic interactions considering the sexual orientation of characters.
   - Increase in likelihood of rebuffing if the initiator is not the ideal gender.
   - Higher propensity for breakups if the current partner is not the ideal gender.
   - Marriage proposals are disabled for relationships where characters do not align with each other's ideal gender preferences.

3. **Psychopath Adjustment**:
   - Psychopaths in the game will remain unaffected by the death of others, regardless of their relationship.
   - No mood or opinion changes for psychopaths in relation to their romantic connections.

4. **Compatibility and Maintenance**:
   - The mod is compatible with old saves and can be safely removed.
   - Not recommended to use alongside the Psychology mod, as it already reworks the same mechanics.

## Coding Patterns and Conventions
- **C# Classes and Methods**:
  - The mod primarily utilizes C# for its core functions and behavior adjustments.
  - Utilizes static classes and methods to streamline interaction workers.
  - Ensure naming consistency and method clarity to maintain readability and functionality.

## XML Integration
- **XML Configuration**:
  - The mod does not contain XML definiitions for integration, focusing solely on C# for advanced behavioral modifications.

## Harmony Patching
- **Class: HPatcher.cs**:
  - Employs Harmony for method interception and modification.
  - Ensure updates are non-destructive and compatible with RimWorld’s base code.
  - Apply patches thoughtfully to prevent conflicts with other mods, especially those altering similar features.

## Suggestions for GitHub Copilot
- **Functionality Extension**:
  - Recommend generating further enhancments or custom scenerios for diverse relationships dynamics.
  - Create additional patches to include more comprehensive mood or opinion modifiers when necessary.

- **Code Efficiency**:
  - Optimize existing methods to reduce computational overhead in large colonies.
  - Implement more descriptive logging within patches for easier debugging and community support.

- **Mod Compatibility**:
  - Develop methods to check for active Psychology mod and adjust behavior dynamically.
  - Explore integration possibilities with other popular mods to expand synchronization and functionality. 

- **Documentation**:
  - Encourage automated generation of method summaries and documentation for future maintainers.
  - Implement markdown comment styles to aid readability and fast navigation for developers.

This guide should aid mod developers in maintaining, extending, and improving the "Less Stupid Romance Attempt (Continued)" mod. By following the structured advice and patterns outlined, the mod can be a thoughtful addition to any modder's portfolio tailored for the RimWorld community.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).

